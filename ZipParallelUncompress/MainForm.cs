using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZipParallelUncompress
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 解凍ボタンを押下。
        /// </summary>
        /// <param name="sender">イベント発生基</param>
        /// <param name="e">イベントオブジェクト</param>
        private void btnUncompressParallel_Click(object sender, EventArgs e)
        {
            try
            {
                //待機状態
                this.Cursor = Cursors.WaitCursor;

                // 出力ディレクトリ
                var outDir = Path.Combine(Path.GetTempPath(), @"ZipParallelUncompress\" + DateTime.Now.ToString("yyyyMMddHHmmss"));

                // スレッド数
                var threadCount = 0;
                try
                {
                    threadCount = int.Parse(txtThreadCount.Text);
                }
                catch (Exception)
                {
                    // 数値の解析に失敗した場合
                    // 本来は処理すべきだが、サンプルなので特にこれと言ったことはしない
                }

                var sw = new System.Diagnostics.Stopwatch();
                // 計測開始
                sw.Start();

                UncompressParallel(outDir, threadCount);

                // 計測停止
                sw.Stop();
                TimeSpan ts = sw.Elapsed;

                txtResult.Text += string.Format("{0}ミリ秒, {1}", sw.ElapsedMilliseconds, outDir) + "\r\n";
            }
            finally
            {
                //元に戻す
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 通常の解凍ボタンを押下。
        /// </summary>
        /// <param name="sender">イベント発生基</param>
        /// <param name="e">イベントオブジェクト</param>
        private void btnUncompressNormal_Click(object sender, EventArgs e)
        {
            try
            {
                //待機状態
                this.Cursor = Cursors.WaitCursor;

                var outDir = Path.Combine(Path.GetTempPath(), @"ZipParallelUncompress\" + DateTime.Now.ToString("yyyyMMddHHmmss"));

                var sw = new System.Diagnostics.Stopwatch();
                // 計測開始
                sw.Start();

                UncompressNormal(outDir);

                // 計測停止
                sw.Stop();
                TimeSpan ts = sw.Elapsed;

                txtResult.Text += string.Format("{0}ミリ秒, {1}", sw.ElapsedMilliseconds, outDir) + "\r\n";

                //元に戻す
                this.Cursor = Cursors.Default;
            }
            finally
            {
                //元に戻す
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// マルチスレッドを使用した解凍。
        /// </summary>
        /// <param name="outDir">出力ディレクトリ</param>
        /// <param name="threadCount">スレッド数</param>
        private void UncompressParallel(string outDir, int threadCount)
        {

            var dirList = new Dictionary<string, bool>(1000);
            var fileList = new List<string>(1000);

            // ZIP書庫を開く
            using (ZipArchive archive = ZipFile.OpenRead(txtArchiveFilePath.Text))
            {

                // 書庫内のファイルとディレクトリを列挙する
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (!string.IsNullOrEmpty(entry.Name))
                    {
                        fileList.Add(entry.FullName);

                        var dir = Path.GetDirectoryName(entry.FullName);
                        if (!dirList.ContainsKey(dir))
                        {
                            dirList[dir] = true;
                        }
                    }
                }

                // 書庫内のファイルのディレクトリのみを先に作成する
                foreach (var dir in dirList.Keys)
                {
                    var createDir = Path.Combine(outDir, dir);
                    if (!Directory.Exists(createDir))
                    {
                        Directory.CreateDirectory(createDir);
                    }
                }

                // 1スレッドあたりの処理数
                var sizePerThread = (int)(fileList.Count / threadCount);

                // 並列処理
                Parallel.For(0, threadCount, id =>
                {
                    // 開始インデックスを計算
                    var sIndex = id * sizePerThread;
                    // 終了インデックスを計算
                    var eIndex = (id + 1) * sizePerThread;
                    if (id == threadCount - 1)
                    {
                        // 最後の場合は、ファイルリストの最後まで位置するようにする
                        eIndex = fileList.Count;
                    }

                    for (int i = sIndex; i < eIndex; i++)
                    {
                        var file = fileList[i];
                        var createFile = Path.Combine(outDir, file);

                        ZipArchiveEntry entry = archive.GetEntry(file);

                        // エントリをファイルとして出力する
                        using (var writer = new FileStream(createFile, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                        {
                            var b = new byte[1024];
                            var br = 0;

                            // 複数スレッドが同時にZIPアーカイブのエントリにアクセスするとエラーになるのでロックする
                            lock (archive)
                            {
                                // エントリを読み込みファイルに書き込む
                                using (Stream reader = entry.Open())
                                {
                                    while ((br = reader.Read(b, 0, b.Length)) > 0)
                                    {
                                        writer.Write(b, 0, br);
                                    }
                                }
                            }
                        }

                    }

                });

            }

        }

        /// <summary>
        /// 通常の解凍。
        /// </summary>
        /// <param name="outDir">出力ディレクトリ</param>
        private void UncompressNormal(string outDir)
        {
            ZipFile.ExtractToDirectory(txtArchiveFilePath.Text, outDir);
        }
    }

}

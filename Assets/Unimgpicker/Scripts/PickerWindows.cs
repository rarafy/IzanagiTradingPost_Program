#if UNITY_STANDALONE
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Windows.Forms;

namespace Kakera
{
    internal class PickerWindows : IPicker
    {
        public void Show(string title, string outputFileName, int maxSize)
        {
            OpenFileDialog open_file_dialog = new OpenFileDialog();
            open_file_dialog.Filter = "pngファイル(.png)|*.png|すべてのファイル (*.*)|*.*";
            open_file_dialog.CheckFileExists = false;
            open_file_dialog.RestoreDirectory = false;
            open_file_dialog.AutoUpgradeEnabled = true;
            open_file_dialog.ShowDialog();
            string path = open_file_dialog.FileName;

            if (path.Length != 0)
            {
                string destination = UnityEngine.Application.persistentDataPath + "/" + outputFileName;
                if (File.Exists(destination))
                    File.Delete(destination);
                File.Copy(path, destination);
                Debug.Log("PickerOSX:" + destination);
                var receiver = GameObject.Find("Unimgpicker");
                if (receiver != null)
                {
                    receiver.SendMessage("OnComplete", UnityEngine.Application.persistentDataPath + "/" + outputFileName);
                }
            }
        }
    }
}
#endif

#region Document_Section

//Qiita - [Unity] OpenFileDialogをWindowsアプリ(exe)で使う
//https://qiita.com/otochan/items/0f20fad94467bb2c2572

//dobon.net - 「ファイルを開く」ダイアログボックスを表示する
//https://dobon.net/vb/dotnet/form/openfiledialog.html

//JOHOBASE - ファイルを開く・名前を付けて保存・フォルダー参照 コモンダイアログ [C#]
//https://johobase.com/file-folder-common-dialog/

#endregion
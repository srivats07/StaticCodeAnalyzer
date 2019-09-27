private void FileDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("File found successfully and passed to server analyzing");
            
            zipFileSender.SendZipFilePath(gitHubPath1);
        }



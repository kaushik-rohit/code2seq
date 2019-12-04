public void OnMediaFileUploaded(MediaFile mediaFile)
        {
            if (MediaFileUploaded != null)
            {
                MediaFileUploaded(new SingleItemEventArgs<MediaFile>(mediaFile));
            }
        }
public void ExtractAllContents( string pathToExtractTo )
        {
            if( String.IsNullOrEmpty(pathToExtractTo) )
                throw new ArgumentNullException();

            while( HasNext() )
            {
                //Make the file path from the details in the archive making the path windows friendly
                string conflatedPath = Path.Combine(pathToExtractTo, CurrentFileName()).Replace('/', Path.DirectorySeparatorChar);
                
                //Create directories - empty ones will be made too
                Directory.CreateDirectory( Path.GetDirectoryName(conflatedPath) );

                //If we have a file extract the contents
                if( !IsDirectory() )
                {
                    using (FileStream fs = File.Create(conflatedPath))
                    {
                       ExtractCurrentFile(fs); 
                    }
                }
            }
        }
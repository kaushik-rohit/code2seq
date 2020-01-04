public bool CheckoutAndUpdateIfDifferent(string filePath, string contents)
        {
            try
            {
                Checkout(filePath);
                File.WriteAllText(filePath, contents);

                return UndoCheckoutIfUnchanged(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to Checkout and Update if Different for file " + filePath + Environment.NewLine + ex);
            }
        }
public override string ToStringValue()
        {
            /*
                hi-entry = hi-targeted-to-uri *( SEMI hi-param )
                hi-targeted-to-uri= name-addr
                hi-param = hi-index / hi-extension
                hi-index = "index" EQUAL 1*DIGIT *(DOT 1*DIGIT)
                hi-extension = generic-param
            */

            StringBuilder retVal = new StringBuilder();

            // name-addr
            retVal.Append(m_pAddress.ToStringValue());

            // Add parameters
            retVal.Append(ParametersToString());

            return retVal.ToString();
        }
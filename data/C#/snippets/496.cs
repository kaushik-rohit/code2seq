public override void Parse(StringReader reader)
        {
            /*
                hi-entry = hi-targeted-to-uri *( SEMI hi-param )
                hi-targeted-to-uri= name-addr
                hi-param = hi-index / hi-extension
                hi-index = "index" EQUAL 1*DIGIT *(DOT 1*DIGIT)
                hi-extension = generic-param
            */

            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            // name-addr
            m_pAddress = new SIP_t_NameAddress();
            m_pAddress.Parse(reader);

            // Parse parameters
            ParseParameters(reader);
        }
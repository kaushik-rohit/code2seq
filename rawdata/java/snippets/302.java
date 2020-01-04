public String sniffEncoding() throws IOException {
        class Eureka extends SAXException {
            final String encoding;
            public Eureka(String encoding) {
                this.encoding = encoding;
            }
        }

        try (InputStream in = Files.newInputStream(file.toPath())) {
            InputSource input = new InputSource(file.toURI().toASCIIString());
            input.setByteStream(in);
            JAXP.newSAXParser().parse(input,new DefaultHandler() {
                private Locator loc;
                @Override
                public void setDocumentLocator(Locator locator) {
                    this.loc = locator;
                }

                @Override
                public void startDocument() throws SAXException {
                    attempt();
                }

                @Override
                public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {
                    attempt();
                    // if we still haven't found it at the first start element, then we are not going to find it.
                    throw new Eureka(null);
                }

                private void attempt() throws Eureka {
                    if(loc==null)   return;
                    if (loc instanceof Locator2) {
                        Locator2 loc2 = (Locator2) loc;
                        String e = loc2.getEncoding();
                        if(e!=null)
                            throw new Eureka(e);
                    }
                }
            });
            // can't reach here
            throw new AssertionError();
        } catch (Eureka e) {
            if(e.encoding!=null)
                return e.encoding;
            // the environment can contain old version of Xerces and others that do not support Locator2
            // in such a case, assume UTF-8 rather than fail, since Jenkins internally always write XML in UTF-8
            return "UTF-8";
        } catch (SAXException e) {
            throw new IOException("Failed to detect encoding of " + file, e);
        } catch (InvalidPathException e) {
            throw new IOException(e);
        } catch (ParserConfigurationException e) {
            throw new AssertionError(e);    // impossible
        }
    }
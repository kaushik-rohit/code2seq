public static DoubleArrayTrie read(InputStream input) throws IOException {
        DoubleArrayTrie trie = new DoubleArrayTrie();
        DataInputStream dis = new DataInputStream(new BufferedInputStream(input));

        trie.compact = dis.readBoolean();
        int baseCheckSize = dis.readInt(); // Read size of baseArr and checkArr
        int tailSize = dis.readInt(); // Read size of tailArr
        ReadableByteChannel channel = Channels.newChannel(dis);

        ByteBuffer tmpBaseBuffer = ByteBuffer.allocate(baseCheckSize * 4);
        channel.read(tmpBaseBuffer);
        tmpBaseBuffer.rewind();
        trie.baseBuffer = tmpBaseBuffer.asIntBuffer();

        ByteBuffer tmpCheckBuffer = ByteBuffer.allocate(baseCheckSize * 4);
        channel.read(tmpCheckBuffer);
        tmpCheckBuffer.rewind();
        trie.checkBuffer = tmpCheckBuffer.asIntBuffer();

        ByteBuffer tmpTailBuffer = ByteBuffer.allocate(tailSize * 2);
        channel.read(tmpTailBuffer);
        tmpTailBuffer.rewind();
        trie.tailBuffer = tmpTailBuffer.asCharBuffer();

        input.close();
        return trie;
    }
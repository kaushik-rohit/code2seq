public void update(float newData) {
        float data = history[0]*decay + newData*(1-decay);

        float[] r = new float[Math.min(history.length+1,historySize)];
        System.arraycopy(history,0,r,1,Math.min(history.length,r.length-1));
        r[0] = data;
        history = r;
    }
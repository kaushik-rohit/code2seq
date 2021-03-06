@Override public void setupLocal() {
    int idx = H2O.SELF.index();
    _result = new NodeProfile[H2O.CLOUD.size()];

    Map<String, Integer> countedStackTraces = new HashMap<>();

    final int repeats = 100;
    for (int i=0; i<repeats; ++i) {
      Map<Thread, StackTraceElement[]> allStackTraces = Thread.getAllStackTraces();
      for (Map.Entry<Thread, StackTraceElement[]> el : allStackTraces.entrySet()) {
        StringBuilder sb = new StringBuilder();
        int j=0;
        for (StackTraceElement ste : el.getValue()) {
          String val = ste.toString();
          // filter out unimportant stuff
          if( j==0 && (   val.equals("sun.misc.Unsafe.park(Native Method)")
                  || val.equals("java.lang.Object.wait(Native Method)")
                  || val.equals("java.lang.Thread.sleep(Native Method)")
                  || val.equals("java.lang.Thread.yield(Native Method)")
                  || val.equals("java.net.PlainSocketImpl.socketAccept(Native Method)")
                  || val.equals("sun.nio.ch.ServerSocketChannelImpl.accept0(Native Method)")
                  || val.equals("sun.nio.ch.DatagramChannelImpl.receive0(Native Method)")
                  || val.equals("java.lang.Thread.dumpThreads(Native Method)")
          ) ) { break; }

          sb.append(ste.toString());
          sb.append("\n");
          j++;
          if (j==_stack_depth) break;
        }
        String st = sb.toString();
        boolean found = false;
        for (Map.Entry<String, Integer> entry : countedStackTraces.entrySet()) {
          if (entry.getKey().equals(st)) {
            entry.setValue(entry.getValue() + 1);
            found = true;
            break;
          }
        }
        if (!found) countedStackTraces.put(st, 1);
      }
      try {
        Thread.sleep(1);
      } catch (InterruptedException e) {
        e.printStackTrace();
      }
    }

    int i=0;
    _result[idx] = new NodeProfile(countedStackTraces.size());
    _result[idx].node_name = H2O.getIpPortString();
    _result[idx].timestamp = System.currentTimeMillis();
    for (Map.Entry<String, Integer> entry : countedStackTraces.entrySet()) {
      _result[idx].stacktraces[i] = entry.getKey();
      _result[idx].counts[i] = entry.getValue();
      i++;
    }

    // sort it
    Map<Integer, String> sorted = new TreeMap<>(Collections.reverseOrder());
    for (int j=0; j<_result[idx].counts.length; ++j) {
      if (_result[idx].stacktraces[j] != null && _result[idx].stacktraces[j].length() > 0)
        sorted.put(_result[idx].counts[j], _result[idx].stacktraces[j]);
    }

    // overwrite results
    String[] sorted_stacktraces = new String[sorted.entrySet().size()];
    int[] sorted_counts = new int[sorted.entrySet().size()];
    i=0;
    for (Map.Entry<Integer, String> e : sorted.entrySet()) {
      sorted_stacktraces[i] = e.getValue();
      sorted_counts[i] = e.getKey();
      i++;
    }
    _result[idx].stacktraces = sorted_stacktraces;
    _result[idx].counts = sorted_counts;
  }
static String link(Key key, String column, long row, String match ) {
    return "/2/Find?key="+key+(column==null?"":"&column="+column)+"&row="+row+(match==null?"":"&match="+match);
  }
public void RedrawScreen()
    {
      Writer.EmptyScreen();

      Stat.DrawStatsBar();

      Map.DrawMapWin();

      Party.DrawPartyWin();

      Journal.DrawMessageWin();

      this.textBox1.Select(0, 0);
    }
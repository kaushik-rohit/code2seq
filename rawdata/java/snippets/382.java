public ArgumentListBuilder toWindowsCommand(boolean escapeVars) {
    	ArgumentListBuilder windowsCommand = new ArgumentListBuilder().add("cmd.exe", "/C");
        boolean quoted, percent;
        for (int i = 0; i < args.size(); i++) {
            StringBuilder quotedArgs = new StringBuilder();
            String arg = args.get(i);
            quoted = percent = false;
            for (int j = 0; j < arg.length(); j++) {
                char c = arg.charAt(j);
                if (!quoted && (c == ' ' || c == '*' || c == '?' || c == ',' || c == ';')) {
                    quoted = startQuoting(quotedArgs, arg, j);
                }
                else if (c == '^' || c == '&' || c == '<' || c == '>' || c == '|') {
                    if (!quoted) quoted = startQuoting(quotedArgs, arg, j);
                    // quotedArgs.append('^'); See note in javadoc above
                }
                else if (c == '"') {
                    if (!quoted) quoted = startQuoting(quotedArgs, arg, j);
                    quotedArgs.append('"');
                }
                else if (percent && escapeVars
                         && ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))) {
                    if (!quoted) quoted = startQuoting(quotedArgs, arg, j);
                    quotedArgs.append('"').append(c);
                    c = '"';
                }
                percent = (c == '%');
                if (quoted) quotedArgs.append(c);
            }
            if(i == 0 && quoted) quotedArgs.insert(0, '"'); else if (i == 0 && !quoted) quotedArgs.append('"');
            if (quoted) quotedArgs.append('"'); else quotedArgs.append(arg);
            
            windowsCommand.add(quotedArgs, mask.get(i));
        }
        // (comment copied from old code in hudson.tasks.Ant)
        // on Windows, executing batch file can't return the correct error code,
        // so we need to wrap it into cmd.exe.
        // double %% is needed because we want ERRORLEVEL to be expanded after
        // batch file executed, not before. This alone shows how broken Windows is...
        windowsCommand.add("&&").add("exit").add("%%ERRORLEVEL%%\"");
        return windowsCommand;
    }
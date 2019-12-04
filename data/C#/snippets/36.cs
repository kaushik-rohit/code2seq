public static string RunPython(string pythonFile, object[] inputObj) {

            ScriptEngine _engine = Python.CreateEngine();

            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pythonFile);

            #region ×Ö·û´®
            var code = @"import sys" + "\n" +
                @"from System.IO import Path" + "\n" +
                @"sys.path.append("".\pythonlib.zip"")" + "\n" +
                @"import clr" + "\n" +
                @"execfile(Path.GetFullPath(r'" + pythonFile + @"'))";
            var source = _engine.CreateScriptSourceFromString(code);

            var scope = _engine.CreateScope();
            source.Execute(scope);
            #endregion

            #region ÎÄ¼þ
            //var source = _engine.CreateScriptSourceFromFile(fileName, Encoding.Default, SourceCodeKind.Statements);

            //CompiledCode _code = source.Compile();

            //var scope = _engine.CreateScope();

            //_code.Execute(scope);
            #endregion

            var main = scope.GetVariable<Func<object[], string>>("start");

            return main(inputObj);

        }
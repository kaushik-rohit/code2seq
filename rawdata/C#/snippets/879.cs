public static void Main()
        {
            CreateCreatives codeExample = new CreateCreatives();
            Console.WriteLine(codeExample.Description);
            codeExample.Run(new AdManagerUser());
        }
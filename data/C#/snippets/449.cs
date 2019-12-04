public override object Execute()
        {
            object result = null;
            string min = string.Empty;
            string max = string.Empty;
            int param1;
            int param2;

            if (this.ParameterList.Count == 2)
            {
                min = this.ParameterList[0].Execute().ToString();
                max = this.ParameterList[1].Execute().ToString();

                if (int.TryParse(min, out param1) && int.TryParse(max, out param2))
                {
                    result = random.Next(param1, param2);
                }
            }
            else
            {
                max = this.ParameterList[0].Execute().ToString();
                if (int.TryParse(max, out param1))
                {
                    result = random.Next(param1);
                }
            }

            return result;
        }
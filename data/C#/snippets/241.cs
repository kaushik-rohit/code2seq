public object Clone()
        {
            LuDecompositionD lud = new LuDecompositionD();
            lud.rows = this.rows;
            lud.cols = this.cols;
            lud.lu = (Decimal[,])this.lu.Clone();
            lud.pivotSign = this.pivotSign;
            lud.pivotVector = (int[])this.pivotVector;
            return lud;
        }
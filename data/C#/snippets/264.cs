internal object Execute(object[] passedParameterValues, bool returnsValue = true)
		{
			this.Initialize(passedParameterValues);

			this.Visit(((LambdaExpression)this.targetExpression).Body);

			if(this.data.Count > 1)
			{
				throw new ExpressionExecutionException("The stack contained too much elements.");
			}
			if(returnsValue && this.data.Count < 1)
			{
				throw new ExpressionExecutionException("The stack contained too few elements.");
			}

			object value = null;

			if(returnsValue)
			{
				value = this.GetValueFromStack();
			}
			
			return value;
		}
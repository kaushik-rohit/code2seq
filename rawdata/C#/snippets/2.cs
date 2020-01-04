public void Execute(Order order, OrderCancelInfo info)
		{
			if (order.Status == OrderStatus.SC)
				order.Cancel(info);
			else if (order.Status == OrderStatus.IP)
				order.Discontinue(info);
			else
				throw new WorkflowException(string.Format("Order with status {0} cannot be cancelled/discontinued.", order.Status));
		}
protected override void WriteHeader()
            {
                var centerStyle = _writer.GetStyle();
                centerStyle.SetHorizontalAlignment(HorizontalAlignmentValues.Center);

                _writer.WriteRow("A", 1, new List<string>
                {
                    "ID",
                    "Order #",
                    "Affiliate ID",

                    // billing contact & address
                    "Billing First Name",
                    "Billing Last Name",
                    "Billing Phone",
                    "Billing Address",
                    "Billing Address2",
                    "Billing City",
                    "Billing Region",
                    "Billing Postal Code",
                    "Billing Country",

                    // shipping contact & address
                    "Shipping First Name",
                    "Shipping Last Name",
                    "Shipping Phone",
                    "Shipping Address",
                    "Shipping Address2",
                    "Shipping City",
                    "Shipping Region",
                    "Shipping Postal Code",
                    "Shipping Country",

                    // shipping columns
                    "Shipping Method",
                    "Shipping Provider",
                    "Shipping Status",
                    "Shipping Discount",
                    "Shipping Discount Details",
                    "Shipping Total",
                    "Adjusted Shipping Total",
                    //end shipping columns

                    "Instructions",
                    "Order Discount",
                    "Order Discount Details",
                    "Handling Total",
                    "Subtotal",
                    "Items Tax",
                    "Shipping Tax",
                    "Tax Total",
                    "Total",
                    "Date",
                    "User Email",
                    "User ID",
                    "Status"
                }, _headerStyle);

                _firstRow = 2;
            }
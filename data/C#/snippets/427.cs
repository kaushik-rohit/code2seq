protected override int WriteOrderRow(OrderSnapshot o, int rowIndex)
            {
                var order = _hccApp.OrderServices.Orders.FindForCurrentStore(o.bvin);

                _writer.WriteRow("A", rowIndex, new List<string>
                {
                    o.bvin,
                    o.OrderNumber,
                    o.AffiliateID.ToString(),

                    // billing contact & address
                    o.BillingAddress.FirstName,
                    o.BillingAddress.LastName,
                    o.BillingAddress.Phone,
                    o.BillingAddress.Line1,
                    o.BillingAddress.Line2,
                    o.BillingAddress.City,
                    o.BillingAddress.RegionDisplayName,
                    o.BillingAddress.PostalCode,
                    o.BillingAddress.CountryDisplayName,

                    // shipping contact & address
                    o.ShippingAddress.FirstName,
                    o.ShippingAddress.LastName,
                    o.ShippingAddress.Phone,
                    o.ShippingAddress.Line1,
                    o.ShippingAddress.Line2,
                    o.ShippingAddress.City,
                    o.ShippingAddress.RegionDisplayName,
                    o.ShippingAddress.PostalCode,
                    o.ShippingAddress.CountryDisplayName,

                    // shipping columns
                    o.ShippingMethodDisplayName,
                    o.ShippingProviderServiceCode,
                    LocalizationUtils.GetOrderShippingStatus(o.ShippingStatus),
                    GetCurrency(o.TotalShippingDiscounts),
                    DiscountDetail.ListToXml(order.ShippingDiscountDetails),
                    GetCurrency(o.TotalShippingBeforeDiscounts),
                    GetCurrency(order.TotalShippingAfterDiscounts),
                    //end shipping columns

                    o.Instructions,
                    GetCurrency(o.TotalOrderDiscounts),
                    DiscountDetail.ListToXml(order.OrderDiscountDetails),
                    GetCurrency(o.TotalHandling),
                    GetCurrency(o.TotalOrderBeforeDiscounts),
                    GetCurrency(o.ItemsTax),
                    GetCurrency(o.ShippingTax),
                    GetCurrency(o.TotalTax),
                    GetCurrency(o.TotalGrand),
                    o.TimeOfOrderUtc.ToString(),
                    o.UserEmail,
                    o.UserID,
                    o.StatusName
                }, _rowStyle);

                return base.WriteOrderRow(o, rowIndex);
            }
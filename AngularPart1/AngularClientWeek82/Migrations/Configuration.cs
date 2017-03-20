namespace AngularClientWeek82.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularClientWeek82.Models.BusinessDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BusinessDBContext context)
        {
            SeedProducts(context);
            SeedCustomers(context);

            base.Seed(context);
        }

        private void SeedCustomers(BusinessDBContext context)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer {
                     Name = "Danny Graham",
                      CreditRating = new Random().Next(2000, 4000),
                         Address="123 Belview Terrace",
                          Orders = new List<Order>
                          {
                              new Order
                              {
                                   EnteredBy="Bill Bloggs",
                                    OrderDate = DateTime.Parse("2016-01-09"),
                                      Orderlines = new List<OrderLine>
                                  {
                                      new OrderLine {
                                          ProductID =  GetProductID(context),
                                           Quantity = new Random().Next(5,10)
                                      }
                                  }
                              },
                              new Order
                              {
                                   EnteredBy="Fred Couples",
                                    OrderDate = DateTime.Parse("2016-01-12"),
                                      Orderlines = new List<OrderLine>
                                  {
                                      new OrderLine {
                                          ProductID =  GetProductID(context),
                                           Quantity = new Random().Next(10,20)
                                      }
                                  }
                              }

                          }
                },
                new Customer {
                     Name = "David O'Grady",
                      CreditRating = new Random().Next(2000, 4000),
                         Address="32 Mayo Way",
                          Orders = new List<Order>
                          {
                              new Order
                              {
                                   EnteredBy="Tommy Tiernan",
                                    OrderDate = DateTime.Parse("2017-01-09"),
                                      Orderlines = new List<OrderLine>
                                  {
                                      new OrderLine {
                                          ProductID =  GetProductID(context),
                                           Quantity = new Random().Next(5,10)
                                      }
                                  }
                              },
                              new Order
                              {
                                   EnteredBy="Tiger Woods",
                                    OrderDate = DateTime.Parse("2016-01-12"),
                                      Orderlines = new List<OrderLine>
                                  {
                                      new OrderLine {
                                          ProductID =  GetProductID(context),
                                           Quantity = new Random().Next(10,20)
                                      }
                                  }
                              },

                          }
                },
                new Customer {
                     Name = "Mark Noble",
                      CreditRating = new Random().Next(2000, 4000),
                         Address="1 London Stadium",
                          Orders = new List<Order>
                          {
                              new Order
                              {
                                   EnteredBy="Bobby Moore",
                                    OrderDate = DateTime.Parse("2016-10-07"),
                                      Orderlines = new List<OrderLine>
                                  {
                                      new OrderLine {
                                          ProductID =  GetProductID(context),
                                           Quantity = new Random().Next(5,10)
                                      },
                                      new OrderLine {
                                          ProductID =  GetProductID(context),
                                           Quantity = new Random().Next(5,10)
                                      },
                                      new OrderLine {
                                          ProductID =  GetProductID(context),
                                           Quantity = new Random().Next(5,10)
                                      }
                                  }
                              },
                              new Order
                              {
                                   EnteredBy="Frank Lampard",
                                    OrderDate = DateTime.Parse("2017-01-25"),
                                      Orderlines = new List<OrderLine>
                                  {
                                      new OrderLine {
                                          ProductID =  GetProductID(context),
                                           Quantity = new Random().Next(10,20)
                                      },
                                      new OrderLine {
                                          ProductID =  GetProductID(context),
                                           Quantity = new Random().Next(5,10)
                                      },
                                      new OrderLine {
                                          ProductID =  GetProductID(context),
                                           Quantity = new Random().Next(5,10)
                                      }
                                  }
                              },

                          }
                },
                new Customer {
                     Name = "Ian Poulter",
                      CreditRating = new Random().Next(2000, 4000),
                         Address="2 Ryder Cup Road",
                          Orders = new List<Order>
                          {
                              new Order
                              {
                                   EnteredBy="Jack Nicolaus",
                                    OrderDate = DateTime.Parse("2015-01-09"),
                                      Orderlines = new List<OrderLine>
                                  {
                                      new OrderLine {
                                          ProductID =  GetProductID(context),
                                           Quantity = new Random().Next(5,10)
                                      }
                                  }
                              },
                              new Order
                              {
                                   EnteredBy="Arnold Palmer",
                                    OrderDate = DateTime.Parse("2016-11-25"),
                                      Orderlines = new List<OrderLine>
                                  {
                                      new OrderLine {
                                          ProductID =  GetProductID(context),
                                           Quantity = new Random().Next(10,20)
                                      }
                                  }
                              },

                          }
                }
            };
            customers.ForEach(c => context.Customers.Add(c));
        }

        private int GetProductID(BusinessDBContext context)
        {
            var selected = new Random().Next(0, context.Products.Count());
            var prod = context.Products.ToList().ElementAt(selected);
            return prod.ID;
        }

        private void SeedProducts(BusinessDBContext context)
        {
            var products = new List<Product>()
            {
                new Product {
                    Description ="9 inch nails",
                     ReorderLevel = 200,
                      ReorderQuantity = 1000,
                       StockOnHand = 320,
                        UnitPrice = 0.25f
                },
                new Product {
                    Description ="6 inch nails",
                     ReorderLevel = 100,
                      ReorderQuantity = 500,
                       StockOnHand = 32,
                        UnitPrice = 0.12f
                },
                new Product {
                    Description ="Glass Hammer",
                     ReorderLevel = 20,
                      ReorderQuantity = 100,
                       StockOnHand = 32,
                        UnitPrice = 50f
                },

                new Product {
                    Description ="Sledge Hammer",
                     ReorderLevel = 20,
                      ReorderQuantity = 100,
                       StockOnHand = 32,
                        UnitPrice = 42.50f
                },
                new Product {
                    Description ="Big Nuts",
                     ReorderLevel = 100,
                      ReorderQuantity = 350,
                       StockOnHand = 220,
                        UnitPrice = 1.0f
                },
                new Product {
                    Description ="Tool Box",
                     ReorderLevel = 10,
                      ReorderQuantity = 35,
                       StockOnHand = 22,
                        UnitPrice = 100.0f
                },

            };
            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();
        }


    }
}

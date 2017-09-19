# Entiry framework
## Best practices
Often using Entity Framework in a rapid application development model is very challanging. There are certain [**Performance Consideration**](https://msdn.microsoft.com/en-in/data/hh949853.aspx) when using Entity Framework in your *applciation development*. 
Few of them are lissted below..

1. Disable Change tracking
   You should disable change tracking if it is not needed. Most importantly, you do not need change tracking when you would just want to retrieve data and updates on the data read aren't needed at all.
2. Reduce the cost of view generation using Pre-generated Views
   The creation of ObjectContext is a costly operation as it involves the cost of loading and validating the metadata. You should take advantage of pre-generated views to reduce the response time when the first request is executed. In essence, the Entity Framework runtime creates a set of classes (also called the view) when the object context is instantiated for the first time.
3. Disable Auto Detection of Changes
   When trying to update the database the Entity Framework needs to know the changes that have been made to an entity from the time it was loaded in memory. This change detection is done by comparing the old values of the properties with the new or changed values when you make a call to the methods like, Find(), Remove(), Add(), Attach() and SaveChanges() methods. This change detection is very costly and can degrade the application's performance primarily when you are working with many entities. You can disable change detection using the following code.

   When you want to disable change detection, it is a good practice to disable it inside a try - catch block and then re-enable it inside the finally block. Note that you can ignore this when you are working with a relatively small set of data - you would get significant performance gains by turning change detection off when you are working with a large set of data.

4. Always use projections
   Use projections to select only the fields that are needed when retrieving data. You should avoid retrieving fields that are not needed.

5. Other rules to be followed 
   -[x] Retrieve data in a paged manner
   -[x] Avoid using `Contains` when using LINQ to Entities
   -[x] Use compiled queries to improve performance of your LINQ queries when retrieving data
   -[x] Beware of using `context` within loop statements - which means you will make multiple calls to database, which is never a good idea.
   -[x] Turn off lazy loading on the context.
   ```c#
    public Context()
    {
        Configuration.LazyLoadingEnabled = false;
        Configuration.ProxyCreationEnabled = false;
    }
   ```
   


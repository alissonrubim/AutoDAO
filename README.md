# AutoDAO
AutoDAO is a project to create automatic Data Access Object that I had made for college.

This project have the objective to create a CRUD (Create Read Update Delete) for products. In this CRUD I use the AutoDAO.

### What is AutoDAO ###
In some king of systems, some developers create DAO's, that is the Database Access Object. For each model class, the developer had to create basically five methods:
   - Insert
   - Update
   - Delete
   - List
   - Get
Each of these methods have your own query and parametres, that is used for communicate with database.

In the AutoDAO, I just have to extends my class, with Model class, and say what is the Table and what are the Columns. Like these:

```csharp
  public class Product {
     public int Id;
     public string Description;
  }

  public class ProductModel: Model<Product> 
  {
     public Product(){
        this.Table = "Product";
        this.Columns.Add(new ModelColumns("Id", isPrimaryKey: true));
        this.Columns.Add(new ModelColumns("Description"));
     }
  }
  ```
  
  Now, i just can call my class, in the form, like this:
  
  ```csharp
     public void AddNew(){
        (new ProductModel).Insert(new Product(){
           Description: "Computer"
        });
     }
     
     public Procut GetByPrimaryKey(int key){
        return (new ProductModel).Get(key);
     }
  ```

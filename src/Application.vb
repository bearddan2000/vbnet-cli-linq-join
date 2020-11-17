Imports System
Imports System.Linq
Imports System.Collections.Generic

Class Rating
    Public Property Id() As Integer = 0
    Public Property Score() As Integer = 0
    
    Public Overrides Function ToString() as String
        Return String.Format("Score: {0}", Score)
    End Function
End Class
Class Food     
    Public Property Name() As String = ""
    Public Property Calorie() As Integer = 0
    Public Property RatingId() As Integer = 0
    
    Public Overrides Function ToString() as String
        Return String.Format("Name: {0}, Calories: {1}", Name, Calorie)
    End Function
End Class
Class Review     
    Public Property Name() As String = ""
    Public Property Calorie() As Integer = 0
    Public Property Score() As Integer = 0
    
    Public Overrides Function ToString() as String
        Return String.Format("Name: {0}, Calories: {1}, Score: {2}", Name, Calorie, Score)
    End Function
End Class
Module Application
    Sub Print(result as IEnumerable(Of Review), query as String)
        Console.WriteLine("[QUERY] {0}", query)
        For Each i as Review in result
            Console.WriteLine("[OUTPUT] {0}", i)
        Next
    End Sub
    Sub GreaterThan(foods as List(Of Food), ratings as List(Of Rating))
        Dim result as IEnumerable(Of Review) = 
                     from f in foods
                     join r in ratings on f.RatingId equals r.Id
                     where f.Calorie > 100
                     select new Review() with {.Name=f.Name, .Calorie=f.Calorie, .Score=r.Score}
        
        Print(result, "SELECT * FROM foods AS f JOIN ratings AS r ON f.RatingId = r.Id WHERE f.Calorie > 100")
    End Sub
    Sub LessThan(foods as List(Of Food), ratings as List(Of Rating))
        Dim result as IEnumerable(Of Review) = 
                     from f in foods
                     join r in ratings on f.RatingId equals r.Id
                     where f.Calorie < 50
                     select new Review() with {.Name=f.Name, .Calorie=f.Calorie, .Score=r.Score}
        
        Print(result, "SELECT * FROM foods AS f JOIN ratings AS r ON f.RatingId = r.Id WHERE f.Calorie < 50")
    End Sub
    Sub EqualTo(foods as List(Of Food), ratings as List(Of Rating))
        Dim result as IEnumerable(Of Review) = 
                     from f in foods
                     join r in ratings on f.RatingId equals r.Id
                     where f.Calorie = 100
                     select new Review() with {.Name=f.Name, .Calorie=f.Calorie, .Score=r.Score}
        
        Print(result, "SELECT * FROM foods AS f JOIN ratings AS r ON f.RatingId = r.Id WHERE f.Calorie = 100")
    End Sub
	Sub Main()
        Dim foods as New List(Of Food) 
        foods.Add(new Food() with {.Name="Cheese Burger", .Calorie=250, .RatingId=1})
        foods.Add(new Food() with {.Name="Cracker", .Calorie=25, .RatingId=2})
        foods.Add(new Food() with {.Name="BLT", .Calorie=100, .RatingId=1})
        
        Dim ratings as New List(Of Rating)
        ratings.Add(new Rating() with {.Id=1, .Score=10})
        ratings.Add(new Rating() with {.Id=2, .Score=3})
        
        Console.WriteLine("[INPUT] {0}", String.Join(Of Food)(", ", foods.ToArray()))
        Console.WriteLine("[INPUT] {0}", String.Join(Of Rating)(", ", ratings.ToArray()))
        
        GreaterThan(foods, ratings)
        LessThan(foods, ratings)
        EqualTo(foods, ratings)
	End Sub
End Module
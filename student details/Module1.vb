Public Class Student
    Public Property Id As Integer
    Public Property Name As String
    Public Property Age As Integer
End Class

Public Class StudentManager
    Private students As New List(Of Student)()

    Public Sub AddOrUpdateStudent(ByVal id As Integer)
        Dim student = students.FirstOrDefault(Function(s) s.Id = id)
        If student Is Nothing Then
            student = New Student()
            students.Add(student)
            student.Id = id
            Console.WriteLine("New student entry created.")
        End If

        'Inputting Student details
        Console.Write("Enter student name: ")
        student.Name = Console.ReadLine()

        Console.Write("Enter student age: ")
        student.Age = Convert.ToInt32(Console.ReadLine())

        Console.WriteLine("Student record updated.")
    End Sub

    'Deleting Student details
    Public Sub DeleteStudent(ByVal id As Integer)
        Dim student = students.FirstOrDefault(Function(s) s.Id = id)
        If student IsNot Nothing Then
            students.Remove(student)
            Console.WriteLine("Student record deleted.")
        Else
            Console.WriteLine("Student not found.")
        End If
    End Sub

    Public Sub DisplayStudents()
        For Each student In students
            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}")
        Next
    End Sub
End Class


'Giving choices whether the user wants to insert update Or delete the student details
Module Module1
    Sub Main()
        Dim manager As New StudentManager()
        Dim choice As Integer
        Do
            Console.WriteLine("1. Add/Update Student")
            Console.WriteLine("2. Delete Student")
            Console.WriteLine("3. Display Students")
            Console.WriteLine("4. Exit")
            Console.Write("Select an option: ")
            choice = Convert.ToInt32(Console.ReadLine())

            Select Case choice
                Case 1
                    Console.Write("Enter student ID: ")
                    Dim id As Integer = Convert.ToInt32(Console.ReadLine())
                    manager.AddOrUpdateStudent(id)
                Case 2
                    Console.Write("Enter student ID to delete: ")
                    Dim id As Integer = Convert.ToInt32(Console.ReadLine())
                    manager.DeleteStudent(id)
                Case 3
                    manager.DisplayStudents()
                Case 4
                    Exit Do
                Case Else
                    Console.WriteLine("Invalid option, please try again.")
            End Select
        Loop While choice <> 4
    End Sub
End Module
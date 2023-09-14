Public Class StudentRepository
    Private studentContext As StudentEntities = Nothing

    Public Sub New()
        studentContext = New StudentEntities()
    End Sub

    Public Function GetStudent(ByVal id As Integer) As Student
        Return studentContext.Students.Find(id)
    End Function

    Public Function GetAll() As List(Of Student)
        Return studentContext.Students.ToList()
    End Function

    Public Sub AddStudent(ByVal student As Student)
        If student IsNot Nothing Then
            studentContext.Students.Add(student)
            studentContext.SaveChanges()
        End If
    End Sub

    Public Sub UpdateStudent(ByVal student As Student)
        Dim studentFind = Me.GetStudent(student.ID)

        If studentFind IsNot Nothing Then
            studentFind.Name = student.Name
            studentFind.Contact = student.Contact
            studentFind.Age = student.Age
            studentFind.Address = student.Address
            studentContext.SaveChanges()
        End If
    End Sub

    Public Sub RemoveStudent(ByVal id As Integer)
        Dim studObj = studentContext.Students.Find(id)

        If studObj IsNot Nothing Then
            studentContext.Students.Remove(studObj)
            studentContext.SaveChanges()
        End If
    End Sub
End Class
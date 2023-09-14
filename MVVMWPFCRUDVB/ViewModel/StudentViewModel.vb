Imports System.Collections.ObjectModel

Public Class StudentViewModel
    Private _saveCommand As ICommand
    Private _resetCommand As ICommand
    Private _editCommand As ICommand
    Private _deleteCommand As ICommand
    Private _repository As StudentRepository
    Private _studentEntity As Student = Nothing
    Public Property StudentRecord As StudentRecord
    Public Property StudentEntities As StudentEntities

    Public ReadOnly Property ResetCommand As ICommand
        Get
            If _resetCommand Is Nothing Then
                _resetCommand = New RelayCommand(AddressOf ResetData, Nothing)
            End If
            Return _resetCommand
        End Get
    End Property

    Public ReadOnly Property SaveCommand As ICommand
        Get
            If _saveCommand Is Nothing Then
                _saveCommand = New RelayCommand(AddressOf SaveData, Nothing)
            End If
            Return _saveCommand
        End Get
    End Property

    Public ReadOnly Property EditCommand As ICommand
        Get
            If _editCommand Is Nothing Then
                _editCommand = New RelayCommand(AddressOf EditData, Nothing)
            End If
            Return _editCommand
        End Get
    End Property

    Public ReadOnly Property DeleteCommand As ICommand
        Get
            If _deleteCommand Is Nothing Then
                _deleteCommand = New RelayCommand(AddressOf DeleteStudent, Nothing)
            End If
            Return _deleteCommand
        End Get
    End Property

    Public Sub New()
        _studentEntity = New Student()
        _repository = New StudentRepository()
        StudentRecord = New StudentRecord()
        GetAll()
    End Sub

    Public Sub ResetData()
        StudentRecord.Name = String.Empty
        StudentRecord.Id = 0
        StudentRecord.Address = String.Empty
        StudentRecord.Contact = String.Empty
        StudentRecord.Age = 0
    End Sub

    Public Sub DeleteStudent(ByVal id As Integer)
        If MessageBox.Show("Confirm delete of this record?", "Student", MessageBoxButton.YesNo) = MessageBoxResult.Yes Then

            Try
                _repository.RemoveStudent(id)
                MessageBox.Show("Record successfully deleted.")
            Catch ex As Exception
                MessageBox.Show("Error occured while saving. " & ex.InnerException.Message)
            Finally
                GetAll()
            End Try
        End If
    End Sub

    Public Sub SaveData()
        If StudentRecord IsNot Nothing Then
            _studentEntity.Name = StudentRecord.Name
            _studentEntity.Age = StudentRecord.Age
            _studentEntity.Address = StudentRecord.Address
            _studentEntity.Contact = StudentRecord.Contact

            Try

                If StudentRecord.Id <= 0 Then
                    _repository.AddStudent(_studentEntity)
                    MessageBox.Show("New record successfully saved.")
                Else
                    _studentEntity.ID = StudentRecord.Id
                    _repository.UpdateStudent(_studentEntity)
                    MessageBox.Show("Record successfully updated.")
                End If

            Catch ex As Exception
                MessageBox.Show("Error occured while saving. " & ex.InnerException.Message)
            Finally
                GetAll()
                ResetData()
            End Try
        End If
    End Sub

    Public Sub EditData(ByVal id As Integer)
        Dim model = _repository.GetStudent(id)
        StudentRecord.Id = model.ID
        StudentRecord.Name = model.Name
        StudentRecord.Age = CInt(model.Age)
        StudentRecord.Address = model.Address
        StudentRecord.Contact = model.Contact
    End Sub

    Public Sub GetAll()
        StudentRecord.StudentRecords = New ObservableCollection(Of StudentRecord)()
        Dim records As New List(Of Student)
        records = _repository.GetAll()

        For Each record As Student In records
            Dim item As New StudentRecord

            item.Id = record.ID
            item.Name = record.Name
            item.Address = record.Address
            item.Age = Convert.ToInt32(record.Age)
            item.Contact = record.Contact

            StudentRecord.StudentRecords.Add(item)
        Next

    End Sub
End Class
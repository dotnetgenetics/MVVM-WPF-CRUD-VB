Imports System.Collections.ObjectModel
Imports System.Collections.Specialized

Public Class StudentRecord
    Inherits ViewModelBase

    Private _id As Integer

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
            OnPropertyChanged("Id")
        End Set
    End Property

    Private _name As String

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
            OnPropertyChanged("Name")
        End Set
    End Property

    Private _age As Integer

    Public Property Age As Integer
        Get
            Return _age
        End Get
        Set(ByVal value As Integer)
            _age = value
            OnPropertyChanged("Age")
        End Set
    End Property

    Private _address As String

    Public Property Address As String
        Get
            Return _address
        End Get
        Set(ByVal value As String)
            _address = value
            OnPropertyChanged("Address")
        End Set
    End Property

    Private _contact As String

    Public Property Contact As String
        Get
            Return _contact
        End Get
        Set(ByVal value As String)
            _contact = value
            OnPropertyChanged("Contact")
        End Set
    End Property

    Private _studentRecords As ObservableCollection(Of StudentRecord)

    Public Property StudentRecords As ObservableCollection(Of StudentRecord)
        Get
            Return _studentRecords
        End Get
        Set(ByVal value As ObservableCollection(Of StudentRecord))
            _studentRecords = value
            OnPropertyChanged("StudentRecords")
        End Set
    End Property

    Private Sub StudentModels_CollectionChanged(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        OnPropertyChanged("StudentRecords")
    End Sub
End Class

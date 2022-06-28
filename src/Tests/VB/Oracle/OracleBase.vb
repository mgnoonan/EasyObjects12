Imports System
Imports System.Data
Imports NCI.EasyObjects
 
Namespace EasyObjects.Tests.Oracle

    Public Class UnitTestBase

        Shared Sub New()
        End Sub

        Public Shared Sub RefreshDatabase()
            Dim obj As AggregateTest = New AggregateTest
            obj.DatabaseInstanceName = "OracleUnitTests"
            obj.DynamicQueryInstanceName = "Default Oracle"

            obj.LoadAll()
            obj.DeleteAll()
            obj.Save()

            Dim i As Integer = 1
            obj.IdentityInsert = True

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "3"
            obj.s_FIRSTNAME = "David"
            obj.s_LASTNAME = "Doe"
            obj.s_AGE = "16"
            obj.s_HIREDATE = "2000-02-16 00:00:00"
            obj.s_SALARY = "34.71"
            obj.s_ISACTIVE = "1"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "1"
            obj.s_FIRSTNAME = "Sarah"
            obj.s_LASTNAME = "McDonald"
            obj.s_AGE = "28"
            obj.s_HIREDATE = "1999-03-25 00:00:00"
            obj.s_SALARY = "11.06"
            obj.s_ISACTIVE = "1"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "3"
            obj.s_FIRSTNAME = "David"
            obj.s_LASTNAME = "Vincent"
            obj.s_AGE = "43"
            obj.s_HIREDATE = "2000-10-17 00:00:00"
            obj.s_SALARY = "10.27"
            obj.s_ISACTIVE = "0"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "2"
            obj.s_FIRSTNAME = "Fred"
            obj.s_LASTNAME = "Smith"
            obj.s_AGE = "15"
            obj.s_HIREDATE = "1999-03-15 00:00:00"
            obj.s_SALARY = "15.15"
            obj.s_ISACTIVE = "1"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "3"
            obj.s_FIRSTNAME = "Sally"
            obj.s_LASTNAME = "Johnson"
            obj.s_AGE = "30"
            obj.s_HIREDATE = "2000-10-07 00:00:00"
            obj.s_SALARY = "14.36"
            obj.s_ISACTIVE = "1"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "5"
            obj.s_FIRSTNAME = "Jane"
            obj.s_LASTNAME = "Rapaport"
            obj.s_AGE = "44"
            obj.s_HIREDATE = "2002-05-02 00:00:00"
            obj.s_SALARY = "13.56"
            obj.s_ISACTIVE = "0"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "4"
            obj.s_FIRSTNAME = "Paul"
            obj.s_LASTNAME = "Gellar"
            obj.s_AGE = "16"
            obj.s_HIREDATE = "2000-09-27 00:00:00"
            obj.s_SALARY = "18.44"
            obj.s_ISACTIVE = "1"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "2"
            obj.s_FIRSTNAME = "John"
            obj.s_LASTNAME = "Jones"
            obj.s_AGE = "31"
            obj.s_HIREDATE = "2002-04-22 00:00:00"
            obj.s_SALARY = "17.65"
            obj.s_ISACTIVE = "1"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "3"
            obj.s_FIRSTNAME = "Michelle"
            obj.s_LASTNAME = "Johnson"
            obj.s_AGE = "45"
            obj.s_HIREDATE = "2003-11-14 00:00:00"
            obj.s_SALARY = "16.86"
            obj.s_ISACTIVE = "0"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "2"
            obj.s_FIRSTNAME = "David"
            obj.s_LASTNAME = "Costner"
            obj.s_AGE = "17"
            obj.s_HIREDATE = "2002-04-11 00:00:00"
            obj.s_SALARY = "21.74"
            obj.s_ISACTIVE = "1"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "4"
            obj.s_FIRSTNAME = "William"
            obj.s_LASTNAME = "Gellar"
            obj.s_AGE = "32"
            obj.s_HIREDATE = "2003-11-04 00:00:00"
            obj.s_SALARY = "20.94"
            obj.s_ISACTIVE = "0"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "3"
            obj.s_FIRSTNAME = "Sally"
            obj.s_LASTNAME = "Rapaport"
            obj.s_AGE = "39"
            obj.s_HIREDATE = "2002-04-01 00:00:00"
            obj.s_SALARY = "25.82"
            obj.s_ISACTIVE = "1"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "5"
            obj.s_FIRSTNAME = "Jane"
            obj.s_LASTNAME = "Vincent"
            obj.s_AGE = "18"
            obj.s_HIREDATE = "2003-10-25 00:00:00"
            obj.s_SALARY = "25.03"
            obj.s_ISACTIVE = "1"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "2"
            obj.s_FIRSTNAME = "Fred"
            obj.s_LASTNAME = "Costner"
            obj.s_AGE = "33"
            obj.s_HIREDATE = "1998-05-20 00:00:00"
            obj.s_SALARY = "24.24"
            obj.s_ISACTIVE = "0"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "1"
            obj.s_FIRSTNAME = "John"
            obj.s_LASTNAME = "Johnson"
            obj.s_AGE = "40"
            obj.s_HIREDATE = "2003-10-15 00:00:00"
            obj.s_SALARY = "29.12"
            obj.s_ISACTIVE = "1"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "3"
            obj.s_FIRSTNAME = "Michelle"
            obj.s_LASTNAME = "Rapaport"
            obj.s_AGE = "19"
            obj.s_HIREDATE = "1998-05-10 00:00:00"
            obj.s_SALARY = "28.32"
            obj.s_ISACTIVE = "1"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "4"
            obj.s_FIRSTNAME = "Sarah"
            obj.s_LASTNAME = "Doe"
            obj.s_AGE = "34"
            obj.s_HIREDATE = "1999-12-03 00:00:00"
            obj.s_SALARY = "27.53"
            obj.s_ISACTIVE = "0"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "4"
            obj.s_FIRSTNAME = "William"
            obj.s_LASTNAME = "Jones"
            obj.s_AGE = "41"
            obj.s_HIREDATE = "1998-04-30 00:00:00"
            obj.s_SALARY = "32.41"
            obj.s_ISACTIVE = "1"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "1"
            obj.s_FIRSTNAME = "Sarah"
            obj.s_LASTNAME = "McDonald"
            obj.s_AGE = "21"
            obj.s_HIREDATE = "1999-11-23 00:00:00"
            obj.s_SALARY = "31.62"
            obj.s_ISACTIVE = "0"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "4"
            obj.s_FIRSTNAME = "Jane"
            obj.s_LASTNAME = "Costner"
            obj.s_AGE = "28"
            obj.s_HIREDATE = "1998-04-20 00:00:00"
            obj.s_SALARY = "36.50"
            obj.s_ISACTIVE = "1"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "2"
            obj.s_FIRSTNAME = "Fred"
            obj.s_LASTNAME = "Douglas"
            obj.s_AGE = "42"
            obj.s_HIREDATE = "1999-11-13 00:00:00"
            obj.s_SALARY = "35.71"
            obj.s_ISACTIVE = "1"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "3"
            obj.s_FIRSTNAME = "Paul"
            obj.s_LASTNAME = "Jones"
            obj.s_AGE = "22"
            obj.s_HIREDATE = "2001-06-07 00:00:00"
            obj.s_SALARY = "34.91"
            obj.s_ISACTIVE = "0"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "3"
            obj.s_FIRSTNAME = "Michelle"
            obj.s_LASTNAME = "Doe"
            obj.s_AGE = "29"
            obj.s_HIREDATE = "1999-11-03 00:00:00"
            obj.s_SALARY = "39.79"
            obj.s_ISACTIVE = "1"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "4"
            obj.s_FIRSTNAME = "Paul"
            obj.s_LASTNAME = "Costner"
            obj.s_AGE = "43"
            obj.s_HIREDATE = "2001-05-28 00:00:00"
            obj.s_SALARY = "39.00"
            obj.s_ISACTIVE = "1"

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.AddNew()
            obj.s_ID = i : i += 1

            obj.AddNew()
            obj.s_ID = i : i += 1
            obj.s_DEPARTMENTID = "0"
            obj.s_FIRSTNAME = ""
            obj.s_LASTNAME = ""
            obj.s_AGE = "0"
            obj.s_SALARY = "0"

            obj.Save()
        End Sub
    End Class
End Namespace

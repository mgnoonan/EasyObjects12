Imports Tests.EasyObjects.Tests.Oracle
Imports NCI.EasyObjects

Module Module1

    Sub Main()

        Console.WriteLine("Refreshing database")
        UnitTestBase.RefreshDatabase()

        'Dim aggTest As AggregateTest = New AggregateTest
        'aggTest.DatabaseInstanceName = "OracleUnitTests"
        'aggTest.DynamicQueryInstanceName = "Default Oracle"
        'aggTest.DefaultCommandType = CommandType.Text
        'UnitTestBase.RefreshDatabase()

        Console.WriteLine("Press ENTER to continue...")
        Console.ReadLine()

    End Sub

End Module

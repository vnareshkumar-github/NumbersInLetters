Public Class Calculator
    'Implements  ICalculator

    Dim ones(9) As String
    Dim teens(8) As String
    Dim tens(9) As String
    Dim hundred as String = "hundred"
    Dim thousand as String = "onethousand"

    Private _Calculator as ICalculator

    Public Sub New()

        ones(0) = "one"
        ones(1) = "two"
        ones(2) = "three"
        ones(3) = "four"
        ones(4) = "five"
        ones(5) = "six"
        ones(6) = "seven"
        ones(7) = "eight"
        ones(8) = "nine"
        ones(9) = "ten"

        teens(0) = "eleven"
        teens(1) = "twelve"
        teens(2) = "thirteen"
        teens(3) = "fourteen"
        teens(4) = "fifteen"
        teens(5) = "sixteen"
        teens(6) = "seventeen"
        teens(7) = "eighteen"
        teens(8) = "nineteen"

        tens(0) = "ten"
        tens(1) = "twenty"
        tens(2) = "thirty"
        tens(3) = "forty"
        tens(4) = "fifty"
        tens(5) = "sixty"
        tens(6) = "seventy"
        tens(7) = "eighty"
        tens(8) = "ninety"
        tens(9) = "hundred"
        
    End Sub

    Public Function CountLetters(min As Integer, max As Integer) As Long 'Implements ICalculator.CountLetters

        
        If min < 1 OrElse min > 1000 OrElse max < 1 OrElse max > 1000 Then
            Throw new Exception("Supported range is 1 - 1000, other ranges not supported yet.")
        End If

        Dim numbersInStringList = Me.GetNumbersList(min, max)

        Dim total as Long
        for each numberString in numbersInStringList
            total += numberString.Length
        Next
     
        Return total
    End Function

    Private Function GetNumbersList(min As Integer, max As Integer) As List(Of String)
        Dim numberStringList as new List(Of String)
        
        For i As Integer = min To max
            numberStringList.Add(Me.GetNumberInLetters(i))
        Next

        Return numberStringList
    End Function

    Private Function GetNumberInLetters(number as Integer) As string
        Dim numberAsString as String = ""

        If number > 0 AndAlso number <= 10 Then
            numberAsString = ones(number - 1)
        ElseIf number > 10 AndAlso number < 20 Then
            numberAsString = teens(number - 11)
        ElseIf number >= 20 AndAlso number < 100 Then
            dim modTen as integer = Math.Floor(number / 10)
            numberAsString += tens(modTen - 1)
            if number Mod 10 <> 0 Then
                numberAsString += ones(number - (modTen*10) -1)
            End If
        ElseIf number = 100 Then
            numberAsString = hundred
        ElseIf number = 1000 Then
            numberAsString = thousand
        ElseIf number > 100 AndAlso number < 1000 Then
            dim modHundred as integer = Math.Floor(number / 100)
            numberAsString += ones(modHundred - 1) 
            numberAsString += hundred

            dim modHun as integer = number Mod 100
            If modHun > 0 AndAlso modHun <= 10 Then
                numberAsString += "and" & ones(modHun - 1)
            ElseIf modHun > 10 AndAlso modHun < 20 Then
                numberAsString += "and"&teens(modHun - 11)
            ElseIf modHun >= 20 AndAlso modHun < 100 Then
                dim modTen as integer = Math.Floor(modHun / 10)
                numberAsString +="and" & tens(modTen-1)
                if modHun Mod 10 <> 0 Then
                    numberAsString += ones(modHun - (modTen*10) -1)
                End If
            End If
        End If

        Return numberAsString
    End Function

    Private Function GetOnes(number as Integer) As string
        Return ones(number -1)
    End Function

    Private Function GetTeens(number as Integer) As string
        Return teens(number -1)
    End Function
    Private Function GetTens(number as Integer) As string
        Return tens(number -1)
    End Function

End Class
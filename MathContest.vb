Public Class MathContest
    Function ValidateFields() As Boolean
        Dim StudentAge As Integer
        Dim StudentGrade As Integer
        Dim ProblemMessage As String
        Dim StudentName As String
        StudentName = CStr(NameTextBox.Text)


        Dim CorrectAnswer As Integer
        Dim StudentAnswer As Integer

        Try
            StudentAnswer = CInt(StudentAnswerTextBox.Text)
        Catch ex As Exception
            ProblemMessage &= "The student answer must be a number" & vbNewLine
            StudentAnswerTextBox.Text = ""
            StudentAnswerTextBox.Focus()
        End Try

        If AddRadioButton.Checked Then
            CorrectAnswer = MathTime(0)
        End If
        If SubtractRadioButton.Checked Then
            CorrectAnswer = MathTime(1)
        End If
        If MultiplyRadioButton.Checked Then
            CorrectAnswer = MathTime(2)
        End If
        If DivideRadioButton.Checked Then
            CorrectAnswer = MathTime(3)
        End If

        Dim FirstNum As Integer
        Dim SecondNum As Integer
        Try
            SecondNum = CInt(SecondNumTextBox.Text)
        Catch ex As Exception
            ProblemMessage &= "The 2nd number must be a number"
            SecondNumTextBox.Text = ""
        End Try
        If SecondNumTextBox.Text = "" Then
            SecondNumTextBox.Focus()
        End If
        Try
            FirstNum = CInt(FirstNumTextBox.Text)
        Catch ex As Exception
            ProblemMessage &= "The 1st number must be a number"
            FirstNumTextBox.Text = ""
        End Try
        If FirstNumTextBox.Text = "" Then
            FirstNumTextBox.Focus()
        End If

        Try
            StudentGrade = CInt(GradeTextBox.Text)
        Catch ex As Exception
            ProblemMessage &= "Grade must be a number between 1 and 4" & vbNewLine
        End Try

        If StudentGrade > 4 Then
            ProblemMessage &= $"{StudentName} is too far along in school to compete" & vbNewLine
            GradeTextBox.Text = ""
            GradeTextBox.Focus()
        End If
        If StudentGrade < 1 Then
            ProblemMessage &= $"{StudentName} has not yet had enough schooling to compete" & vbNewLine
            GradeTextBox.Text = ""
            GradeTextBox.Focus()
        End If

        Try
            StudentAge = CInt(AgeTextBox.Text)
        Catch ex As Exception
            ProblemMessage &= "Age must be a number between 7 and 11" & vbNewLine
        End Try

        If StudentAge > 11 Then
            ProblemMessage &= $"{StudentName} is too old to compete" & vbNewLine
            AgeTextBox.Text = ""
            AgeTextBox.Focus()
        End If
        If StudentAge < 7 Then
            ProblemMessage &= $"{StudentName} is too young to compete" & vbNewLine
            AgeTextBox.Text = ""
            AgeTextBox.Focus()
        End If

        If NameTextBox.Text = "" Then
            ProblemMessage &= "The student's name is required" & vbNewLine
            NameTextBox.Focus()
        End If

        If ProblemMessage <> "" Then
            MsgBox(ProblemMessage)
        Else
            If StudentAnswer = CorrectAnswer Then
                MsgBox($"Correct! Well done {StudentName}" & vbNewLine)
            Else
                MsgBox($"Incorrect. Get it together {StudentName}. The correct answer is {CorrectAnswer}" & vbNewLine)
            End If
        End If

    End Function

    Function MathTime(ByRef MathType As Integer) As Integer
        Dim FirstNum As Integer
        Dim SecondNum As Integer
        Dim CorrectAnswer As Integer
        Try
            FirstNum = CInt(FirstNumTextBox.Text)
            SecondNum = CInt(SecondNumTextBox.Text)
        Catch ex As Exception
            MsgBox("Math can only be done with 2 numbers")
        End Try
        Select Case MathType
            Case 0
                CorrectAnswer = FirstNum + SecondNum
            Case 1
                CorrectAnswer = FirstNum - SecondNum
            Case 2
                CorrectAnswer = FirstNum * SecondNum
            Case 3
                CorrectAnswer = FirstNum / SecondNum
        End Select
        Return CorrectAnswer
    End Function

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub



    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        ValidateFields()




    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        NameTextBox.Text = ""
        AgeTextBox.Text = ""
        GradeTextBox.Text = ""
        FirstNumTextBox.Text = ""
        SecondNumTextBox.Text = ""
        StudentAnswerTextBox.Text = ""

    End Sub

    Private Sub AddRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles AddRadioButton.CheckedChanged
        MathTime(0)
    End Sub

    Private Sub SubtractRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles SubtractRadioButton.CheckedChanged
        MathTime(1)
    End Sub

    Private Sub MultiplyRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles MultiplyRadioButton.CheckedChanged
        MathTime(2)
    End Sub

    Private Sub DivideRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles DivideRadioButton.CheckedChanged
        MathTime(3)
    End Sub


End Class

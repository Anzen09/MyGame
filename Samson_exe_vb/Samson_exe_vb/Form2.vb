Public Class Form2

    Dim wins As Integer = 0
    Dim losses As Integer = 0
    Dim ties As Integer = 0
    Dim roundsPlayed As Integer = 0

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeGame()
        My.Computer.Audio.Play("D:\Prgramming\Samson_exe_vb\New folder\jungle-6432.wav")
    End Sub

    Private Sub InitializeGame()
        roundsPlayed = 0
        wins = 0
        losses = 0
        ties = 0
        ResetVisuals()
    End Sub

    Private Sub ResetVisuals()
        PictureBox1.Visible = False
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False
        PictureBox6.Visible = False
        Label1.Text = ""
        Label5.Text = wins
        Label6.Text = losses
        Label7.Text = ties
    End Sub

    Private Sub EvaluateGame(playerChoice As Integer)
        Dim rnd As New Random
        Dim comp As Integer = rnd.Next(3) + 1
        Label9.Text = comp

        If comp = 1 Then
            PictureBox5.Visible = True
            If playerChoice = 3 Then
                Label1.Text = "It's a tie"
                ties += 1
            ElseIf playerChoice = 2 Then
                Label1.Text = "Computer wins"
                losses += 1
            ElseIf playerChoice = 1 Then
                Label1.Text = "Player wins"
                wins += 1
            End If
        ElseIf comp = 2 Then
            PictureBox4.Visible = True
            If playerChoice = 2 Then
                Label1.Text = "Player wins"
                wins += 1
            ElseIf playerChoice = 1 Then
                Label1.Text = "It's a tie"
                ties += 1
            ElseIf playerChoice = 3 Then
                Label1.Text = "Computer wins"
                losses += 1
            End If
        ElseIf comp = 3 Then
            PictureBox6.Visible = True
            If playerChoice = 1 Then
                Label1.Text = "Computer wins"
                losses += 1
            ElseIf playerChoice = 3 Then
                Label1.Text = "Player wins"
                wins += 1
            ElseIf playerChoice = 2 Then
                Label1.Text = "It's a tie"
                ties += 1
            End If
        End If

        roundsPlayed += 1
        UpdateScoreboard()

        If roundsPlayed = 5 Then
            DetermineWinner()
        End If
    End Sub

    Private Sub UpdateScoreboard()
        Label5.Text = wins
        Label6.Text = losses
        Label7.Text = ties
    End Sub

    Private Sub DetermineWinner()
        If wins > losses Then
            MessageBox.Show("Player wins the best of five!")
        ElseIf losses > wins Then
            MessageBox.Show("Computer wins the best of five!")
        Else
            MessageBox.Show("It's a tie in the best of five!")
        End If

        InitializeGame()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PictureBox1.Visible = False
        PictureBox2.Visible = False
        PictureBox3.Visible = True
        PictureBox4.Visible = False
        PictureBox5.Visible = False
        PictureBox6.Visible = False
        EvaluateGame(1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PictureBox1.Visible = True
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False
        PictureBox6.Visible = False
        EvaluateGame(2)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PictureBox1.Visible = False
        PictureBox2.Visible = True
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False
        PictureBox6.Visible = False
        EvaluateGame(3)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub
End Class
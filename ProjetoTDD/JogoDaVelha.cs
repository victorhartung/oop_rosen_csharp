namespace ProjetoTDD;

public class JogoDaVelha
{
    private string[,] _tabuleiro = new string[3, 3];
    public bool TemGanhador;

    public bool Preencher(int linha, int coluna, string desenho)
    {
        var simbolo = desenho == "X" ? "X" : "O";

        if (!VerificarPosicaoValida(linha, coluna))
        {
            MostrarTabuleiro();
            return false;
        }

        _tabuleiro[--linha, --coluna] = simbolo;
        MostrarTabuleiro();
        ChecarGanhador(simbolo);
        ChecarEmpate();
        return true;
    }

    private bool VerificarPosicaoValida(int linha, int coluna)
    {
        var linhaValida = linha is >= 1 and <= 3;
        var colunaValida = coluna is >= 1 and <= 3;

        if (linhaValida && colunaValida)
        {
            return !VerificarPosicaoPreenchida(linha, coluna);
        }

        Console.WriteLine("Posição inválida");
        return false;
    }

    private bool VerificarPosicaoPreenchida(int linha, int coluna)
    {
        if (_tabuleiro[linha - 1, coluna - 1] != "X" && _tabuleiro[linha - 1, coluna - 1] != "O") return false;
        Console.WriteLine("Posição já preenchida, escolha outra");
        return true;
    }

    public void MostrarTabuleiro()
    {
        for (var i = 0; i < _tabuleiro.GetLength(0); i++)
        {
            for (var j = 0; j < _tabuleiro.GetLength(1); j++)
            {
                Console.Write(j == 2 ? $"{_tabuleiro[i, j]}" : $"{_tabuleiro[i, j]}| ");
            }

            Console.WriteLine(i == 2 ? "" : "\n---");
        }
    }

    private void ChecarGanhador(string simbolo)
    {
        var ganhouLinha = ChecarGanhadorLinha();
        var ganhouColuna = ChecarGanhadorColuna();
        var ganhouDiagonal = ChecarGanhadorDiagonal();

        if (!ganhouLinha && !ganhouColuna && !ganhouDiagonal) return;

        Console.WriteLine($"{simbolo} ganhou!");
        TemGanhador = true;
    }

    private bool ChecarGanhadorLinha()
    {
        for (var i = 0; i < _tabuleiro.GetLength(0); i++)
        {
            if ((_tabuleiro[i, 0] == "X" || _tabuleiro[i, 0] == "O") && _tabuleiro[i, 0] == _tabuleiro[i, 1] &&
                _tabuleiro[i, 1] == _tabuleiro[i, 2])
            {
                return true;
            }
        }

        return false;
    }
    
    private bool ChecarGanhadorColuna()
    {
        for (var i = 0; i < _tabuleiro.GetLength(0); i++)
        {
            if ((_tabuleiro[0, i] == "X" || _tabuleiro[0, i] == "O") && _tabuleiro[0, i] == _tabuleiro[1, i] &&
                _tabuleiro[1, i] == _tabuleiro[2, i])
            {
                return true;
            }
        }

        return false;
    }

    private bool ChecarGanhadorDiagonal()
    {
        if ((_tabuleiro[0, 0] == "X" || _tabuleiro[0, 0] == "O") && _tabuleiro[0, 0] == _tabuleiro[1, 1] &&
            _tabuleiro[1, 1] == _tabuleiro[2, 2])
        {
            return true;
        }

        return (_tabuleiro[0, 2] == "X" || _tabuleiro[0, 2] == "O") && _tabuleiro[0, 2] == _tabuleiro[1, 1] &&
               _tabuleiro[1, 1] == _tabuleiro[2, 0];
    }

    private void ChecarEmpate()
    {
        var empatou = !TemGanhador && _tabuleiro.Cast<string?>().All(i => i != null && (i.Equals("X") || i.Equals("O")));

        if (!empatou) return;
        Console.WriteLine("Ocorreu um empate! Limpando o tabuleiro...");
        LimparTabuleiro();
    }

    private void LimparTabuleiro()
    {
        _tabuleiro = new string[3, 3];
        TemGanhador = false;
    }
}
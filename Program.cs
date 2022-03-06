// See https://aka.ms/new-console-template for more information

using System.Numerics;

try
{    
    #region Etapa 1 - Escolher p e q (números primos) para o cálculo de N = p.q
    string msg = "The information security is of significant importance to ensure the privacy of communications";
    Console.WriteLine("Mensagem = " + msg);
    Console.WriteLine();
    string msgCrip = "";
    string msgDecrip = "";
    int p = 17, q = 41;
    int n = p * q;
    int e = 2;
    #endregion

    #region Etapa 2 - Calcular a função totiente tot(N) = (p-1).(q-1) 

    int totN = (p - 1) * (q - 1);
    #endregion

    #region Etapa 3 - Escolha 1 < e < tot(N), tal que e e tot(N)sejam primos entre si

    bool verdadeiro = false;
    while (!verdadeiro)
    {
        int a = MDC(totN, e);
        if (a == 1)
        {
            verdadeiro = true;
        }
        else
        {
            e++;
        }
    }

    #endregion

    #region Etapa 4 - Escolha d tal que e.d mod (N) =1
    
    verdadeiro = false;
    int d = 1;
    while (!verdadeiro)
    {
        int a = (e * d) % totN;
        if (a == 1)
        {
            verdadeiro = true;
        }
        else
        {
            d++;
        }
    }
    #endregion

    #region Chaves Assimetricas

    #region Criptografar - Chave Pública (e,N) => C = P^e mod N    
    int valorLetra = 0;
    BigInteger novaLetra = 0;
    foreach (char letra in msg)
    {
        valorLetra = ((byte)letra);
        novaLetra = BigInteger.Pow((valorLetra), (e)) % n;
        msgCrip += novaLetra + " ";
    }
    Console.WriteLine("Mensagem Criptografada = " + msgCrip.Remove(msgCrip.Length - 1));
    Console.WriteLine();
    #endregion

    #region Decriptografar - Chave Privada (d,N) => P = C^d mod N
    BigInteger voltaLetra;
    foreach (string valor in msgCrip.Remove(msgCrip.Length - 1).Split(" "))
    {
        voltaLetra = BigInteger.Pow((Convert.ToInt32(valor)), (d)) % n;
        msgDecrip += ((char)voltaLetra);
    }
    Console.WriteLine("Mensagem Decriptografada = " + msgDecrip);
    Console.WriteLine();
    Console.ReadLine();
    #endregion

    #endregion
}
catch (Exception e)
{
    Console.WriteLine("{ 0} Exception caught.", e);
}

#region Metodo Máximo divisor comum

int MDC(int a, int b)
{
    int resto;
    while (b != 0)
    {
        resto = a % b;
        a = b;
        b = resto;
    }
    return a;
}
#endregion
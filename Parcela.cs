class Parcela
{
    // Atributos
    public string tipoCultivo;
    public int mesesRestantes;
    public double ingresoEsperado;

    // Constructor
    public Parcela()
    {
        tipoCultivo = "Libre";
        mesesRestantes = 0;
        ingresoEsperado = 0;
    }

    // Verifica si la parcela está vacía
    public bool EstaVacia()
    {
        return tipoCultivo == "Libre";
    }

    // Método para sembrar
    public void Sembrar(string cultivo, int meses, double ingreso)
    {
        tipoCultivo = cultivo;
        mesesRestantes = meses;
        ingresoEsperado = ingreso;
    }

    // Reduce el tiempo de crecimiento
    public void Crecer()
    {
        if (mesesRestantes > 0)
        {
            mesesRestantes--;
        }
    }

    // Cosecha el cultivo y libera la parcela
    public double Cosechar()
    {
        double ganancia = ingresoEsperado;

        tipoCultivo = "Libre";
        mesesRestantes = 0;
        ingresoEsperado = 0;

        return ganancia;
    }
}

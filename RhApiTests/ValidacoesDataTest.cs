using RhApi.Services;

namespace rhapitests;

public class ValidacoesDataTest
{
    [Fact]
    public void ValidarSeDataNaoFoiInformada()
    {
        //Arrange
        var data = DateTime.MinValue;

        //Act
        bool resultado = ValidacoesData.DataNaoInformada(data);

        //Assert
        Assert.True(resultado);
    }

    [Fact]
    public void ValidarSeDataEhAnteriorAhFundacaoDaEmpresa()
    {
        //Arrange
        var data = new DateTime(2019, 12, 31);

        //Act
        bool resultado = ValidacoesData.DataAnteriorFundacaoDaEmpresa(data);

        //Assert
        Assert.True(resultado);
    }
}
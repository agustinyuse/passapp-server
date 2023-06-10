using Domain.ValueObjects;
using System.Text;

public static class AddressHelper
{
    public static string? GetFullAddressDescription(ProfessionalAddress address)
    {
        if (address is null)
        {
            return null;
        }

        StringBuilder descriptionBuilder = new StringBuilder();

        // Agregar la calle y el número de la dirección
        descriptionBuilder.Append($"{address.Address}");

        // Agregar la ciudad, el estado, el país y el código postal
        descriptionBuilder.Append($", {address.City}, {address.State}, {address.Country}");

        if (!string.IsNullOrEmpty(address.ZipCode))
        {
            descriptionBuilder.Append($", {address.ZipCode}");
        }

        return descriptionBuilder.ToString();
    }
}

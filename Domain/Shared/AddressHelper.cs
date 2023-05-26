using Domain.ValueObjects;
using System.Text;

public static class AddressHelper
{
    public static string GetFullAddressDescription(ProfessionalAddress address)
    {
        StringBuilder descriptionBuilder = new StringBuilder();

        // Agregar la calle y el número de la dirección
        descriptionBuilder.Append($"{address.Street} {address.Number}");

        // Agregar las calles adyacentes si están presentes
        if (!string.IsNullOrEmpty(address.AdjacentStreet1))
        {
            descriptionBuilder.Append($", {address.AdjacentStreet1}");
        }

        if (!string.IsNullOrEmpty(address.AdjacentStreet2))
        {
            descriptionBuilder.Append($", {address.AdjacentStreet2}");
        }

        // Agregar el piso y la unidad si están presentes
        if (!string.IsNullOrEmpty(address.Floor))
        {
            descriptionBuilder.Append($", Floor {address.Floor}");
        }

        if (!string.IsNullOrEmpty(address.Unit))
        {
            descriptionBuilder.Append($", Unit {address.Unit}");
        }

        // Agregar la ciudad, el estado, el país y el código postal
        descriptionBuilder.Append($", {address.City}, {address.State}, {address.Country}");

        if (!string.IsNullOrEmpty(address.ZipCode))
        {
            descriptionBuilder.Append($", {address.ZipCode}");
        }

        return descriptionBuilder.ToString();
    }
}

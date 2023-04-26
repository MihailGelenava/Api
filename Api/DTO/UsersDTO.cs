using Newtonsoft.Json;

namespace RestAPI.DTO
{
    public class UsersDTO
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as UsersDTO);
        }
        public bool Equals(UsersDTO other)
        {
            return this.Id == other.Id && this.Name.Equals(other.Name) && this.Username.Equals(other.Username) 
                && this.Website.Equals(other.Website) && this.Email.Equals(other.Email) && this.Address.Equals(other.Address)
                && this.Company.Equals(other.Company) && this.Phone.Equals(other.Phone);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id,Name,Username,Website,Email,Address,Company,Phone);
        }

    }
    public partial class Address
    {
        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("suite")]
        public string Suite { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }

        [JsonProperty("geo")]
        public Geo Geo { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Address);
        }
        public bool Equals(Address other)
        {
            return this.Street.Equals(other.Street) && this.Suite.Equals(other.Suite) && this.City.Equals(other.City )
                && this.Zipcode.Equals(other.Zipcode) && this.Geo.Equals(other.Geo);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Street, Suite, City, Zipcode, Geo);
        }
    }
    public partial class Geo
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("lng")]
        public string Lng { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Geo);
        }
        public bool Equals(Geo other)
        {
            return this.Lat.Equals(other.Lat) && this.Lng.Equals(other.Lng);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Lat,Lng);
        }
    }
    public partial class Company
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("catchPhrase")]
        public string CatchPhrase { get; set; }

        [JsonProperty("bs")]
        public string Bs { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Company);
        }
        public bool Equals(Company other)
        {
            return this.Name.Equals(other.Name) && this.CatchPhrase.Equals(other.CatchPhrase) && this.Bs.Equals(other.Bs);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name,CatchPhrase,Bs);
        }
    }
}

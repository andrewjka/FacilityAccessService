/*
 * Facility Access Service API
 *
 * The service an access control system for facilities within the enterprise territory.
 *
 * The version of the OpenAPI document: 1.0.0
 * 
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using FacilityAccessService.RestService.Converters;

namespace FacilityAccessService.RestService.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class User : IEquatable<User>
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="Id", EmitDefaultValue=false)]
        public string Id { get; set; }


        /// <summary>
        /// Gets or Sets Role
        /// </summary>
        [TypeConverter(typeof(CustomEnumConverter<RoleEnum>))]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum RoleEnum
        {
            
            /// <summary>
            /// Enum GuestEnum for guest
            /// </summary>
            [EnumMember(Value = "guest")]
            GuestEnum = 1,
            
            /// <summary>
            /// Enum EmployeeEnum for employee
            /// </summary>
            [EnumMember(Value = "employee")]
            EmployeeEnum = 2,
            
            /// <summary>
            /// Enum GuardEnum for guard
            /// </summary>
            [EnumMember(Value = "guard")]
            GuardEnum = 3,
            
            /// <summary>
            /// Enum AdministratorEnum for administrator
            /// </summary>
            [EnumMember(Value = "administrator")]
            AdministratorEnum = 4
        }

        /// <summary>
        /// Gets or Sets Role
        /// </summary>
        [DataMember(Name="Role", EmitDefaultValue=true)]
        public RoleEnum Role { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class User {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((User)obj);
        }

        /// <summary>
        /// Returns true if User instances are equal
        /// </summary>
        /// <param name="other">Instance of User to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(User other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) && 
                (
                    Role == other.Role ||
                    
                    Role.Equals(other.Role)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    
                    hashCode = hashCode * 59 + Role.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(User left, User right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(User left, User right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}

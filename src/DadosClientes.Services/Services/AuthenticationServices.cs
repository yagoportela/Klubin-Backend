using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using DadosClientes.Domain.Core.Dto.Configuration;
using DadosClientes.Domain.Core.Interfaces.Services;
using DadosClientes.Domain.Core.Models;
using Microsoft.Extensions.Configuration;

namespace DadosClientes.Infra.Services.Services {
    public class AuthenticationServices : IAuthenticationServices {

        private readonly Authorization _authorization;
        public AuthenticationServices (Authorization authorization) {
            _authorization = authorization;
        }

        public string teste() {
            return _authorization.ClientId;
        }

        public async Task<string> Register (User user) {

            try {
                var cognito = new AmazonCognitoIdentityProviderClient ();

                var request = new SignUpRequest {
                    ClientId = _authorization.ClientId,
                    SecretHash = GetSecretHash (user.Username, _authorization.ClientId, _authorization.AppSecretKey),
                    Password = user.Password,
                    Username = user.Username,
                };

                request.UserAttributes.Add (new AttributeType {
                    Name = "email",
                        Value = user.Email

                });

                request.UserAttributes.Add (new AttributeType {
                    Name = "phone_number",
                        Value = "+5511953684990"

                });

                request.UserAttributes.Add (new AttributeType {
                    Name = "name",
                        Value = user.Username

                });

                var response = await cognito.SignUpAsync (request);

                return response.UserSub;

            } catch (Exception ex) {
                string message = ex.Message;
                throw new System.NotImplementedException ();
            }

        }

        public async Task<string> SignIn (UserLogin user) {
            try {
                var cognito = new AmazonCognitoIdentityProviderClient ();

                var request = new AdminInitiateAuthRequest {
                    UserPoolId = _authorization.UserPoolId,
                    ClientId = _authorization.ClientId,
                    AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH,

                    AuthParameters = new Dictionary<string, string> { 
                        { "USERNAME", user.Username },
                        { "PASSWORD", user.Password },
                        { "SECRET_HASH", GetSecretHash (user.Username, _authorization.ClientId, _authorization.AppSecretKey) }
                    }
                };

                var response = await cognito.AdminInitiateAuthAsync (request);

                return response.AuthenticationResult.IdToken;

            } catch (Exception ex) {
                return ex.Message;
            }

        }

        public static string GetSecretHash (string username, string appClientId, string appSecretKey) {
            var dataString = username + appClientId;

            var data = Encoding.UTF8.GetBytes (dataString);
            var key = Encoding.UTF8.GetBytes (appSecretKey);

            return Convert.ToBase64String (HmacSHA256 (data, key));
        }

        public static byte[] HmacSHA256 (byte[] data, byte[] key) {
            using (var shaAlgorithm = new System.Security.Cryptography.HMACSHA256 (key)) {
                var result = shaAlgorithm.ComputeHash (data);
                return result;
            }
        }
    }
}
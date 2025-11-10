using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;

namespace MyRecipeBook.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
        {
            // Validar Entrada do Usuário
            ValidateRequest(request);

            //Mapear a Request para uma entidade de domínio

            //Criptografar a senha

            // Persistir a entidade de domínio

            return new ResponseRegisteredUserJson
            {
               Name = request.Name
            };
        }

        private void ValidateRequest(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage);
                throw new ArgumentException($"Invalid user registration data: {errors}");
            }
        }
    }
}

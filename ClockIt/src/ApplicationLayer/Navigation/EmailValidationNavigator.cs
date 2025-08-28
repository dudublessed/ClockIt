using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace ClockIt.src.ApplicationLayer.Navigation
{
    public class EmailValidationNavigator : IEmailValidationNavigator
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IEmailService _emailService;

        public EmailValidationNavigator(IServiceProvider serviceProvider, IEmailService emailService)
        {
            _serviceProvider = serviceProvider;
            _emailService = emailService;
        }

        public IEmailValidationForm EmailValidationForm => _serviceProvider.GetRequiredService<IEmailValidationForm>();

        public IEmailService EmailService => _emailService;
    }
}

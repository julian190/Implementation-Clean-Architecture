﻿using AutoMapper;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using HR.LeaveManagment.Application.Contracts.Presistance;
using HR.LeaveManagment.Application.DTOs.LeaveType;
using HR.LeaveManagment.Application.Features.LeaveTypes.Handlers.Commands;
using HR.LeaveManagment.Application.Profiles;
using HR.LeaveManagment.Application.Responses;
using HR.LeaveManagment.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HR.LeaveManagment.Application.UnitTests.LeaveTypes
{
    public class CreateLeaveTypeCommandHandlerTests
    {   
        private readonly IMapper _mapper;
        private readonly Mock <IUnitOfWork> _mockUow;
        private readonly CreateLeaveTypeDto _createLeaveTypeDto;
        private readonly CreateLeaveTypeCommandtHandler _handler;


     

        public CreateLeaveTypeCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            var MapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = MapperConfig.CreateMapper();
            _handler = new CreateLeaveTypeCommandtHandler(_mapper, _mockUow.Object);
            _createLeaveTypeDto = new CreateLeaveTypeDto() { 
            DefaultDays = 15,
            Name  = "Test DTO"
            };
        }
        [Fact]
        public async Task Valid_LeaveType_Added()
        {
            var result = await _handler.Handle(new Features.LeaveTypes.Requests.Commands.CreateLeaveTypeCommand() { LeaveTypeDto = _createLeaveTypeDto },CancellationToken.None);
            var leavetypes = await _mockUow.Object.LeaveTypeRepository.GetAll();
            result.ShouldBeOfType<BaseCommandResponse>();
            leavetypes.Count().ShouldBe(4);
        }
        [Fact]
        public async Task Invalid_LeaveType_Added()
        {
            _createLeaveTypeDto.DefaultDays = -1;
            var Result = await _handler.Handle(new Features.LeaveTypes.Requests.Commands.CreateLeaveTypeCommand() { LeaveTypeDto = _createLeaveTypeDto },CancellationToken.None);
            var leaveTypes = await _mockUow.Object.LeaveTypeRepository.GetAll();
            leaveTypes.Count().ShouldBe(3);
            Result.ShouldBeOfType<BaseCommandResponse>();
        }
    }
}

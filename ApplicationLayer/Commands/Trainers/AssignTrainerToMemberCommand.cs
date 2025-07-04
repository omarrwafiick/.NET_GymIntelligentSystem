﻿ 
using MediatR;

namespace ApplicationLayer.Commands.Trainers
{ 
    public record AssignTrainerToMemberCommand(
        string MemberId, string TrainerId
    ) : IRequest<bool>;
}

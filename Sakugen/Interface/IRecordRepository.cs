﻿using Sakugen.Dto;

namespace Sakugen.Interface
{
    public interface IRecordRepository
    {
        public Task<RecordDto> CreateRecord(string url);
        
        public RecordDto GetRecord(string token);
    }
}

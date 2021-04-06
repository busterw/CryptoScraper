using CryptoScraper.KeywordLogic.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrpytoScraper.KeywordLogic.Implementations
{
    public class KeywordGrabberHandler
    {
        private readonly IKeywordGrabberRequestSender _keywordGrabberRequestSender;
        public KeywordGrabberHandler(IKeywordGrabberRequestSender keywordGrabberRequestSender)
        {
            _keywordGrabberRequestSender = keywordGrabberRequestSender;
        }
        public string SendRequestToKeywordGrabber()
        {
            throw new NotImplementedException();
        }
    }
}

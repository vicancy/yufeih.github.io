﻿using Google.Protobuf;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using Jil;

[MemoryDiagnoser]
public class JsonVsJilVsProtobuf
{
    [Benchmark]
    public object proto()
    {
        var message = new Message();
        message.MergeFrom(Data.ToByteArray());
        return message;
    }

    [Benchmark]
    public object json()
    {
        return JsonConvert.DeserializeObject<Message>(JsonConvert.SerializeObject(Data));
    }

    [Benchmark]
    public object jil()
    {
        return JSON.Deserialize<Message>(JSON.Serialize(Data));
    }

    private static readonly Message Data = new Message
    {
        AudioSeconds = 10,
        AudioId = "adfasfda8172681736182731",
        ImageId = "ajfoiwjflkwejfwlkjkjioll",
        Text = "Hello, what are you doing how",
        Status = MessageStatus.Failed,
        CreatedAt = long.MaxValue,
    };
}
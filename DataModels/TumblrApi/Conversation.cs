﻿using System.Runtime.Serialization;

namespace ScraperOne.DataModels.TumblrApi;

[DataContract]
public class Conversation
{
    [DataMember(Name = "name", EmitDefaultValue = false)]
    public string Name { get; set; }

    [DataMember(Name = "label", EmitDefaultValue = false)]
    public string Label { get; set; }

    [DataMember(Name = "phrase", EmitDefaultValue = false)]
    public string Phrase { get; set; }
}
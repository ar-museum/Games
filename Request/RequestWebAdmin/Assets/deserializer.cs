using SimpleJSON;
using System;
using System.Collections.Generic;

namespace Request
{
    class Deserializers
    {
        private delegate T DeserializeSomething<T>(JSONNode node);

        private static List<T> DeserializeList<T>(JSONNode node, DeserializeSomething<T> deserialize)
        {
            var result = new List<T>();

            foreach (var i in node.AsArray)
            {
                result.Add(deserialize(i));
            }

            return result;
        }

        public static List<Author> DeserializeAuthorList(JSONNode node) => DeserializeList(node, DeserializeAuthor);

        public static Author DeserializeAuthor(JSONNode node)
        {
            var author = new Author();

            author.AuthorId = node["author_id"];
            author.FullName = node["full_name"];
            author.BornYear = node["born_year"];
            author.DiedYear = node["died_year"];
            author.Location = node["location"];
            author.PhotoId = node["photo_id"];
            author.StaffId = node["staff_id"];
            string createdAt = node["created_at"];
            author.CreatedAt = Convert.ToDateTime(createdAt);
            string updatedAt = node["updated_at"];
            author.UpdatedAt = Convert.ToDateTime(updatedAt);
            author.PhotoPath = node["photo_path"];

            return author;
        }
    }
}
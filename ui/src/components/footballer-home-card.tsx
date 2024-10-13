import Image from "next/image";
import { Button } from "./ui/button";
import { ClipboardListIcon, Trash2, MessageCircleQuestion } from "lucide-react";

interface Props {
    name: string;
    footballClub: string;
    position: string;
    imageUrl: string;
}

export function WishlistFootballerCard({ name, footballClub, position, imageUrl }: Props) {
    return (
        <div className="flex gap-x-5">
            <Image alt="placeholder" src={imageUrl} width={100} height={100}
                className="rounded-md" />

            <div className="flex flex-col w-full">
                <h3 className="text-xl font-semibold">{name}</h3>
                <p>{footballClub} <span className="text-muted-foreground">•</span> {position}</p>

                <div className="flex justify-end space-x-3 w-full">
                    <Button variant="outline" className="flex gap-x-2"><MessageCircleQuestion /> Request</Button>
                    <Button variant="destructive" className="flex gap-x-2"><Trash2 /> Remove</Button>
                </div>
            </div>
        </div>
    )
}


export function MyPlayersFootballerCard({ name, footballClub, position, imageUrl }: Props) {
    return (
        <div className="flex gap-x-5">
            <Image alt="placeholder" src={imageUrl} width={100} height={100}
                className="rounded-md" />

            <div className="flex flex-col w-full">
                <h3 className="text-xl font-semibold">{name}</h3>
                <p>{footballClub} <span className="text-muted-foreground">•</span> {position}</p>

                <div className="flex justify-end space-x-3 w-full">
                    <Button variant="outline" className="flex gap-x-2"><ClipboardListIcon /> Transfer List</Button>
                    <Button variant="destructive" className="flex gap-x-2"><Trash2 /> Remove</Button>
                </div>
            </div>
        </div>
    )
}


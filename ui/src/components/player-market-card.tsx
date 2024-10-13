"use client"

import { useState } from "react"
import Image from "next/image"
import MakeOfferDialog from "./make-offer-dialog"
import { Button } from "./ui/button"
import { Heart } from "lucide-react"

interface Props {
    name: string
    footballClub: string
    position: string
    imageUrl: string
    owner?: string
}

export default function PlayerMarketCard({ name, footballClub, position, imageUrl, owner }: Props) {
    const [offerAmount, setOfferAmount] = useState("")

    const handleSubmitOffer = (e: React.FormEvent) => {
        e.preventDefault()
        // Here you would handle the offer submission, e.g., sending it to an API
        console.log(`Offer of ${offerAmount} submitted for ${name}`)
        // Reset the form and close the dialog
        setOfferAmount("")
    }

    return (
        <div className="flex gap-x-5">
            <Image alt={`${name} profile`} src={imageUrl} width={100} height={100} className="rounded-md" />

            <div className="flex flex-col w-full">
                <h3 className="text-xl font-semibold">{name}</h3>
                <p>
                    {footballClub} <span className="text-muted-foreground">•</span> {position}
                </p>

                <div className="flex items-center justify-end space-x-4 w-full mt-auto">
                    {owner && (
                        <p className="text-muted-foreground">
                            Owned by <span className="font-bold">{owner}</span>
                        </p>
                    )}
                    
                    <Button variant="secondary" className="">
                        <Heart className="mr-2 size-4" />
                        Wishlist
                    </Button>
                    <MakeOfferDialog onSubmit={handleSubmitOffer} offerAmount={offerAmount} setOfferAmount={setOfferAmount} playerName={name} />
                </div>
            </div>
        </div>
    )
}